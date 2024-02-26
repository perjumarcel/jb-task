import { useCallback } from "react";
import { useTicker } from "../context/TickerContext";
import { Symbol } from "../types/symbol";

export const useSymbolManager = () => {
    const { tickerService, symbols, setSymbols } = useTicker();

    const addSymbol = useCallback(async (symbol: string) => {
        await tickerService.subscribeSymbol(symbol);
        setSymbols(prevSymbols => ({
            ...prevSymbols,
            [symbol]: { name: symbol, value: 0} as unknown as Symbol
        }));

    }, [tickerService, setSymbols]);

    const removeSymbol = useCallback((symbolToRemove: string) => {
        const newSymbols = { ...symbols };
        delete newSymbols[symbolToRemove];
        setSymbols(newSymbols);
        tickerService.unsubscribeSymbol(symbolToRemove);
    }, [tickerService, symbols, setSymbols]);

    return { addSymbol, removeSymbol };
}