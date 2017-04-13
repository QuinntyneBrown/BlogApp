import { AppRouterOutletComponent } from "./app-router-outlet.component";
import { Storage, TENANT_KEY } from "./utilities";

const template = require("./app.component.html");
const styles = require("./app.component.scss");

export class AppComponent extends HTMLElement {
    constructor(
        private _storage: Storage = Storage.Instance
    ) {
        super();
    }
    connectedCallback() {
        this._storage.put({ name: TENANT_KEY, value: "81d1409a-13b5-43d8-a3b0-bf9d29bc6aa0" });
        this.innerHTML = `<style>${styles}</style>${template}`;
        new AppRouterOutletComponent(this.querySelector(".router-outlet"));
    }
}

customElements.define(`ce-app`, AppComponent);