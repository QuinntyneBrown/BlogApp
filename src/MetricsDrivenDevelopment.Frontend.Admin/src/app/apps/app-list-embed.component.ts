import { App } from "./app.model";

const template = require("./app-list-embed.component.html");
const styles = require("./app-list-embed.component.scss");

export class AppListEmbedComponent extends HTMLElement {
    constructor(
        private _document: Document = document
    ) {
        super();
    }


    static get observedAttributes() {
        return [
            "apps"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {        
        for (let i = 0; i < this.apps.length; i++) {
            let el = this._document.createElement(`ce-app-item-embed`);
            el.setAttribute("entity", JSON.stringify(this.apps[i]));
            this.appendChild(el);
        }    
    }

    apps:Array<App> = [];

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "apps":
                this.apps = JSON.parse(newValue);
                if (this.parentElement)
                    this.connectedCallback();
                break;
        }
    }
}

customElements.define("ce-app-list-embed", AppListEmbedComponent);
