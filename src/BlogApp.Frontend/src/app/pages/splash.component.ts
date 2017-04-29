import { ApiService } from "../shared";

const template = require("./splash.component.html");
const styles = require("./splash.component.scss");

export class SplashComponent extends HTMLElement {
    constructor(
        private _apiService: ApiService = ApiService.Instance
    ) {
        super();
    }
    
    private _articles: Array<any> = [];

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {
        this._articles = await this._apiService.getArticles();
        this.articlesElement.articles = this._articles;
    }
    
    private get articlesElement() { return this.querySelector("ce-articles") as any; }
}

customElements.define(`ce-splash`,SplashComponent);