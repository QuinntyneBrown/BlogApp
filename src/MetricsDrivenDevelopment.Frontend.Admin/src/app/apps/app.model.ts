export class App { 
    public id:any;
    public name:string;

    public fromJSON(data: { name:string }): App {
        let app = new App();
        app.name = data.name;
        return app;
    }
}
