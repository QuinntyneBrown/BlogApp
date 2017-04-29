import { Router } from "../router";

const template = require("./header.component.html");
const styles = require("./header.component.scss");

export class HeaderComponent extends HTMLElement {
    constructor(
        private _router: Router = Router.Instance
    ) {
        super();
        this.navigateToDefaultUrl = this.navigateToDefaultUrl.bind(this);
    }

    public get titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._setEventListeners();
    }

    public navigateToDefaultUrl() {
        this._router.navigate([""]);
    }
    
    private _setEventListeners() {
        this.titleElement.addEventListener("click", this.navigateToDefaultUrl);
    }

    disconnectedCallback() {
        this.titleElement.removeEventListener("click", this.navigateToDefaultUrl);
    }
}

customElements.define(`ce-header`,HeaderComponent);
