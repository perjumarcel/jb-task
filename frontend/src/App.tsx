import React from 'react';

import './App.css';
import { TickerProvider } from './context/TickerContext';
import { SymbolForm } from './components/SymbolForm.Component';
import { SymbolGrid } from './components/SymbolGrid.Component';

const App: React.FC = () => {
  
  return (
    <TickerProvider>
      <div className="App">
        <SymbolForm />
        <SymbolGrid />
      </div>
    </TickerProvider>
  );
}

export default App;
