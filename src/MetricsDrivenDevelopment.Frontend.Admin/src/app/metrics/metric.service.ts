import { fetch } from "../utilities";
import { Metric } from "./metric.model";

export class MetricService {
    constructor(private _fetch = fetch) { }

    private static _instance: MetricService;

    public static get Instance() {
        this._instance = this._instance || new MetricService();
        return this._instance;
    }

    public get(): Promise<Array<Metric>> {
        return this._fetch({ url: "/api/metric/get", authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { metrics: Array<Metric> }).metrics;
        });
    }

    public getById(id): Promise<Metric> {
        return this._fetch({ url: `/api/metric/getbyid?id=${id}`, authRequired: true }).then((results:string) => {
            return (JSON.parse(results) as { metric: Metric }).metric;
        });
    }

    public add(metric) {
        return this._fetch({ url: `/api/metric/add`, method: "POST", data: { metric }, authRequired: true  });
    }

    public remove(options: { id : number }) {
        return this._fetch({ url: `/api/metric/remove?id=${options.id}`, method: "DELETE", authRequired: true  });
    }
    
}
