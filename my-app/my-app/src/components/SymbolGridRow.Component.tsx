import { memo } from 'react';
import { Symbol } from '../types/symbol';
import { useSymbolManager } from '../hooks/useSymbolManager';

export interface SymbolGridRowProps {
    symbol: Symbol;
}

const SymbolGridRow : React.FC<SymbolGridRowProps> = ({ symbol }) => {
    const { removeSymbol } = useSymbolManager();

    return (
        <div className="grid-row">
        <div className="grid-item">{symbol.name}</div>
        <div className="grid-item">{symbol.value.toFixed(2)}</div>
        <div className="grid-item">
          <button onClick={() => removeSymbol(symbol.name)}>Close</button>
        </div>
      </div>
    )
}

export default memo(SymbolGridRow);