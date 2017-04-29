import { Article } from "../models";

const template = require("./article.component.html");
const styles = require("./article.component.scss");

export class ArticleComponent extends HTMLElement {
    constructor() {
        super();
    }

    public article: Article;
    
    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {
        this.titleElement.textContent = this.article.title;

        this.htmlContentElement.innerHTML = this.article.htmlContent;

        this.contributorElement.innerHTML = `${this.article.author.firstname} ${this.article.author.lastname}`;

        this.dateElement.innerHTML = moment(this.article.published).format("MMM Do YYYY");
    }

    public get titleElement(): HTMLElement { return this.querySelector(".article-title") as HTMLElement; }

    public get htmlContentElement(): HTMLElement { return this.querySelector(".article-html-content") as HTMLElement; }

    public get contributorElement(): HTMLElement { return this.querySelector(".article-contributor") as HTMLElement; }

    public get dateElement(): HTMLElement { return this.querySelector(".article-date") as HTMLElement; }

}

customElements.define(`ce-article`,ArticleComponent);
