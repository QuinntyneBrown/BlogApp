import { AppAdd, AppDelete, AppEdit, appActions } from "./app.actions";
import { App } from "./app.model";
import { AppService } from "./app.service";

const template = require("./app-master-detail.component.html");
const styles = require("./app-master-detail.component.scss");

export class AppMasterDetailComponent extends HTMLElement {
    constructor(
        private _appService: AppService = AppService.Instance	
	) {
        super();
        this.onAppAdd = this.onAppAdd.bind(this);
        this.onAppEdit = this.onAppEdit.bind(this);
        this.onAppDelete = this.onAppDelete.bind(this);
    }

    static get observedAttributes () {
        return [
            "apps"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        this.apps = await this._appService.get();
        this.appListElement.setAttribute("apps", JSON.stringify(this.apps));
    }

    private _setEventListeners() {
        this.addEventListener(appActions.ADD, this.onAppAdd);
        this.addEventListener(appActions.EDIT, this.onAppEdit);
        this.addEventListener(appActions.DELETE, this.onAppDelete);
    }

    disconnectedCallback() {
        this.removeEventListener(appActions.ADD, this.onAppAdd);
        this.removeEventListener(appActions.EDIT, this.onAppEdit);
        this.removeEventListener(appActions.DELETE, this.onAppDelete);
    }

    public async onAppAdd(e) {

        await this._appService.add(e.detail.app);
        this.apps = await this._appService.get();
        
        this.appListElement.setAttribute("apps", JSON.stringify(this.apps));
        this.appEditElement.setAttribute("app", JSON.stringify(new App()));
    }

    public onAppEdit(e) {
        this.appEditElement.setAttribute("app", JSON.stringify(e.detail.app));
    }

    public async onAppDelete(e) {

        await this._appService.remove(e.detail.app.id);
        this.apps = await this._appService.get();
        
        this.appListElement.setAttribute("apps", JSON.stringify(this.apps));
        this.appEditElement.setAttribute("app", JSON.stringify(new App()));
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "apps":
                this.apps = JSON.parse(newValue);

                if (this.parentNode)
                    this.connectedCallback();

                break;
        }
    }

    public get value(): Array<App> { return this.apps; }

    private apps: Array<App> = [];
    public app: App = <App>{};
    public get appEditElement(): HTMLElement { return this.querySelector("ce-app-edit-embed") as HTMLElement; }
    public get appListElement(): HTMLElement { return this.querySelector("ce-app-list-embed") as HTMLElement; }
}

customElements.define(`ce-app-master-detail`,AppMasterDetailComponent);
