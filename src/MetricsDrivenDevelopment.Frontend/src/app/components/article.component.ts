import { Article } from "../models";

const template = require("./article.component.html");
const styles = require("./article.component.scss");

export class ArticleComponent extends HTMLElement {
    constructor() {
        super();
    }

    private _article: Article;

    static get observedAttributes () {
        return [
            "article"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {

    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "article":
                this._article = JSON.parse(newValue) as Article;
                break;
        }
    }
}

customElements.define(`ce-article`,ArticleComponent);
