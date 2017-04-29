const template = require("./about.component.html");
const styles = require("./about.component.scss");

export class AboutComponent extends HTMLElement {
    constructor() {
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
        this.imageElement.src = "https://quinntynebrown.blob.core.windows.net/4204672e-f64a-4edb-8e5c-01c79b7bcb70/headshot_square.png"
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