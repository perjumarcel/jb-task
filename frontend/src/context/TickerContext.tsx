import React, { ReactNode, createContext, useContext, useEffect, useMemo, useState } from "react";
import { StockTickerService, SubscribeToUpdatesCallback } from "../services/StockTickerService";
import { Symbol } from "../types/symbol";

interface TickerContextType {
  tickerService?: StockTickerService;
  symbols: Record<string, Symbol>;
  setSymbols: React.Dispatch<React.SetStateAction<Record<string, Symbol>>>;
}

interface TickerProviderProps {
  children: ReactNode;
}

const TickerContext = createContext<TickerContextType | null>(null);

export const useTicker = () => {
  const context = useContext(TickerContext);
  if (!context) throw new Error("useTicker must be withing TickerProvider");

  return context;
};

export const TickerProvider = ({ children }: TickerProviderProps) => {
  const [tickerService, setTickerService] = useState<StockTickerService>();
  const [symbols, setSymbols] = useState<Record<string, Symbol>>({});

  const subscribeCallback: SubscribeToUpdatesCallback = (updatedSymbol, value) => {
    setSymbols((currentSymbols) => {
      if (updatedSymbol in currentSymbols) {
        return {
          ...currentSymbols,
          [updatedSymbol]: {
            ...currentSymbols[updatedSymbol],
            value: value,
          },
        };
      }
      return currentSymbols;
    });
  };

  useEffect(() => {
    setTickerService(StockTickerService.getInstance());
  }, []);

  useEffect(() => {
    if (tickerService) {
      try {
        tickerService.startConnection().then(() => {
          tickerService.subscribeToUpdates(subscribeCallback);
        });
      } catch (error) {}
    }

    return () => {
      tickerService?.stopConnection();
    };
  }, [tickerService]);

  const contextValue = useMemo(() => ({ tickerService, symbols, setSymbols }), [tickerService, symbols, setSymbols]);

  return <TickerContext.Provider value={contextValue}>{children}</TickerContext.Provider>;
};
