import { useCallback } from "react";
import { useTicker } from "../context/TickerContext";

export const useSymbolManager = () => {
    const { tickerService, symbols, setSymbols } = useTicker();

    const addSymbol = useCallback(async (symbol: string) => {
        if(tickerService) {
            await tickerService.subscribeSymbol(symbol);
            setSymbols(prevSymbols => {
                if(!(symbol in prevSymbols)){
                    return {
                        ...prevSymbols,
                        [symbol]: { name: symbol, value: 0 }
                    }
                }
                return prevSymbols;
            });
        }
    }, [tickerService, setSymbols]);

    const removeSymbol = useCallback((symbolToRemove: string) => {
        if(tickerService) {
            const newSymbols = { ...symbols };
            delete newSymbols[symbolToRemove];
            setSymbols(newSymbols);
            tickerService?.unsubscribeSymbol(symbolToRemove);
        }
    }, [tickerService, symbols, setSymbols]);

    return { addSymbol, removeSymbol };
}