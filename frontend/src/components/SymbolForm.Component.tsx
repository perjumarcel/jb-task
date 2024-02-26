import { useState } from "react"
import { useSymbolManager } from "../hooks/useSymbolManager";

export const SymbolForm: React.FC = () => {
    const [symbol, setSymbol] = useState<string>('');
    const { addSymbol } = useSymbolManager();

    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await addSymbol(symbol);
        setSymbol('');
    }

    return (
        <form onSubmit={handleSubmit}>
            <input
                type="text"
                value={symbol}
                onChange={e => setSymbol(e.target.value)}
                placeholder="Enter Symbol"
            />
            <button type="submit">Add Symbol</button>
        </form>
    )
}