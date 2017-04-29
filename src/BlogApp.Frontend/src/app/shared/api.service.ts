import { fetch } from "../utilities";
import { environment } from "../environment";
import { Article, Personality } from "../models";

export class ApiService {
    constructor(private _fetch = fetch) { }

    private static _instance: ApiService;

    public static get Instance() {
        this._instance = this._instance || new this();
        return this._instance;
    }

    public getArticles(options: { skip?: number, take?: number } = {}): Promise<Array<any>> {         
        return this._fetch({ url: `${environment.articleBaseUrl}api/article/get?skip=${options.skip}&take=${options.take}` }).then((results: string) => {
            return (JSON.parse(results) as { articles: Array<any> }).articles as Array<any>;
        });
    }  

    public getArticleBySlug(options: {
        slug: string
    }): Promise<string> {
        return this._fetch({ url: `${environment.articleBaseUrl}api/article/getBySlug?slug=${options.slug}` }).then((results: string) => {
            return (JSON.parse(results) as { article: any }).article as any;
        });
    }    

    public getPersonalityById(options: { id: any }): Promise<Personality> {
        return this._fetch({ url: `${environment.personalityBaseUrl}api/personality/getById?id=${options.id}` }).then((results: string) => {
            return (JSON.parse(results) as { personality: Personality }).personality as Personality;
        });
    }
}
