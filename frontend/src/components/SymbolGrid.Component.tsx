import SymbolGridRow from "./SymbolGridRow.Component";
import { useTicker } from "../context/TickerContext"

export const SymbolGrid: React.FC = () => {
    const { symbols } = useTicker();

    return (
        <div className="grid">
            <div className="grid-header">
                <div className="grid-header-item">Symbol</div>
                <div className="grid-header-item">Value</div>
                <div className="grid-header-item">Actions</div>
            </div>
            {Object.entries(symbols).map(([name, sym]) => (
                <SymbolGridRow key={name} symbol={sym} />
            ))}
      </div>
    )
}