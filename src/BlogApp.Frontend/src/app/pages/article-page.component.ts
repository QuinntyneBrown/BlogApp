import { ApiService } from "../shared";

const template = require("./article-page.component.html");
const styles = require("./article-page.component.scss");

export class ArticlePageComponent extends HTMLElement {
    constructor(
        private _apiService: ApiService = ApiService.Instance
    ) {
        super();
    }

    public slug: string;

    public get articleElemnt() { return this.querySelector("ce-article") as any; }

    static get observedAttributes () {
        return [
            "slug"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {
        var article = await this._apiService.getArticleBySlug({ slug: this.slug });
        this.articleElemnt.article = article;
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "slug":
                this.slug = newValue;    
                break;
        }
    }
}

customElements.define(`ce-article-page`,ArticlePageComponent);
