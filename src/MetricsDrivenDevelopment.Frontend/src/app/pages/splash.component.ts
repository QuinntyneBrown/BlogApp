import { ApiService } from "../shared";

const template = require("./splash.component.html");
const styles = require("./splash.component.scss");

export class SplashComponent extends HTMLElement {
    constructor(
        private _apiService: ApiService = ApiService.Instance
    ) {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    private _articles: Array<any> = [];

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        this._articles = await this._apiService.getArticles();
        for (let i = 0; i < this._articles.length; i++) {
            let element = document.createElement("ce-article") as any;
            element.article = this._articles[i];
            this.appendChild(element);
        }
    }

    private _setEventListeners() {

    }

    disconnectedCallback() {

    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            default:
                break;
        }
    }
}

customElements.define(`ce-splash`,SplashComponent);