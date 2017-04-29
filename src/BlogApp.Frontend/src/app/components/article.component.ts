import { Article } from "../models";
import { Router } from "../router";

const template = require("./article.component.html");
const styles = require("./article.component.scss");

export class ArticleComponent extends HTMLElement {
    constructor(
        private _router: Router = Router.Instance
    ) {
        super();
        this.onTitleClick = this.onTitleClick.bind(this);
    }

    private _article: Article;

    public get article(): Article { return this._article; }

    public set article(value: Article) {
        this._article = value;
        this._bind();
    }
    
    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    _setEventListeners() {
        this.titleElement.addEventListener("click", this.onTitleClick);
    }

    disconnectedCallback() {
        this.titleElement.removeEventListener("click", this.onTitleClick);
    }
    private onTitleClick() {
        this._router.navigate(["article", this.article.slug]);
    }

    private async _bind() {
        if (this.article) {
            this.titleElement.textContent = this.article.title;

            this.htmlContentElement.innerHTML = this.article.htmlContent;

            this.contributorElement.innerHTML = `${this.article.author.firstname} ${this.article.author.lastname}`;

            this.dateElement.innerHTML = moment(this.article.published).format("MMM Do YYYY");
        }
    }

    public get titleElement(): HTMLElement { return this.querySelector(".article-title") as HTMLElement; }

    public get htmlContentElement(): HTMLElement { return this.querySelector(".article-html-content") as HTMLElement; }

    public get contributorElement(): HTMLElement { return this.querySelector(".article-contributor") as HTMLElement; }

    public get dateElement(): HTMLElement { return this.querySelector(".article-date") as HTMLElement; }

}

customElements.define(`ce-article`,ArticleComponent);
