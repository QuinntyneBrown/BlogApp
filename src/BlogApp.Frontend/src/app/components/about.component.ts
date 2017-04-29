import { ApiService } from "../shared";

const template = require("./about.component.html");
const styles = require("./about.component.scss");

export class AboutComponent extends HTMLElement {
    constructor(
        private _apiService: ApiService = ApiService.Instance
    ) {
        super();
    }

    static get observedAttributes () {
        return [];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        var personality = await this._apiService.getPersonalityById({ id: 1 });        
        this.imageElement.src = personality.imageUrl;
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

    private get imageElement() { return this.querySelector("img"); }
}

customElements.define(`ce-about`,AboutComponent);