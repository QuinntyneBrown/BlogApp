import { ApiService } from "../shared";

const template = require("./article-preview-page.component.html");
const styles = require("./article-preview-page.component.scss");

export class ArticlePreviewPageComponent extends HTMLElement {
    constructor(
        private _apiService: ApiService = ApiService.Instance
    ) {
        super();
    }

    static get observedAttributes () {
        return [
            "slug",
        ];
    }

    public slug;

    public get articleElement() { return this.querySelector("ce-article") as any; }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {
        var article = await this._apiService.getPreviewArticleBySlug({ slug: this.slug });
        this.articleElement.article = article;
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "slug":
                this.slug = newValue;
                break;
        }
    }
    
}

customElements.define(`ce-article-preview-page`,ArticlePreviewPageComponent);
