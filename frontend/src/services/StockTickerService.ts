import { HubConnection, HubConnectionBuilder, HubConnectionState } from "@microsoft/signalr";

const STOCK_TICKER_HUB_URL = 'http://localhost:5063/stockTickerHub'; // Ensure this matches your server configuration

export type SubscribeToUpdatesCallback = (updatedSymbol: string, value: number) => void

export class StockTickerService {
    private static instance: StockTickerService;
    private connection: HubConnection; 
    
    constructor() {
        this.connection = new HubConnectionBuilder()
            .withUrl(STOCK_TICKER_HUB_URL) 
            .withAutomaticReconnect()
            .build();
    }

    public static getInstance(): StockTickerService {
        if(!StockTickerService.instance) {
            StockTickerService.instance = new StockTickerService();
        }

        return StockTickerService.instance;
    }

    async startConnection(): Promise<void> {
        if(this.connection.state !== HubConnectionState.Connecting && this.connection.state !== HubConnectionState.Connected) {
            return this.connection.start().catch((error) => console.error('Connection failed: ', error));
        }
    }

    async stopConnection(): Promise<void> {
        if(this.connection && (this.connection.state === HubConnectionState.Connecting || this.connection.state === HubConnectionState.Connected)) {
            return this.connection.stop();
        }
    }

    async subscribeSymbol(symbol: string): Promise<void> {
        try {
            await this.connection.invoke("Subscribe", symbol);
        }
        catch(error) {
            console.error(error);
        }
    }
    
    async unsubscribeSymbol(symbol: string): Promise<void> {
        try {
            await this.connection.invoke("Unsubscribe", symbol);
        }
        catch(error) {
            console.error(error);
        }
    }

    async subscribeToUpdates(callback: SubscribeToUpdatesCallback): Promise<void> {
        this.connection.on("ReceiveUpdate", callback);
    }
}