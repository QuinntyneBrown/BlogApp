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
        this._storage.put({ name: TENANT_KEY, value: "4204672e-f64a-4edb-8e5c-01c79b7bcb70" });        
        this.innerHTML = `<style>${styles}</style>${template}`;
        new AppRouterOutletComponent(this.querySelector(".router-outlet"));
    }
}

customElements.define(`ce-app`, AppComponent);