export class Metric { 
    public id:any;
    public name:string;

    public fromJSON(data: { name:string }): Metric {
        let metric = new Metric();
        metric.name = data.name;
        return metric;
    }
}
