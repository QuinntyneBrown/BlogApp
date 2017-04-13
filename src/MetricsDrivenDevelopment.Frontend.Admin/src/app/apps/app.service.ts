import { fetch } from "../utilities";
import { App } from "./app.model";

export class AppService {
    constructor(private _fetch = fetch) { }

    private static _instance: AppService;

    public static get Instance() {
        this._instance = this._instance || new AppService();
        return this._instance;
    }

    public get(): Promise<Array<App>> {
        return this._fetch({ url: "/api/app/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { apps: Array<App> }).apps;
        });
    }

    public getById(id): Promise<App> {
        return this._fetch({ url: `/api/app/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { app: App }).app;
        });
    }

    public add(app) {
        return this._fetch({ url: `/api/app/add`, method: "POST", data: { app }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/app/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
