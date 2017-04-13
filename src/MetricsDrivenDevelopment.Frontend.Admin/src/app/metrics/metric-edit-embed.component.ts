import { Metric } from "./metric.model";
import { EditorComponent } from "../shared";
import {  MetricDelete, MetricEdit, MetricAdd } from "./metric.actions";

const template = require("./metric-edit-embed.component.html");
const styles = require("./metric-edit-embed.component.scss");

export class MetricEditEmbedComponent extends HTMLElement {
    constructor() {
        super();
        this.onSave = this.onSave.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    static get observedAttributes() {
        return [
            "metric",
            "metric-id"
        ];
    }
    
    connectedCallback() {        
        this.innerHTML = `<style>${styles}</style> ${template}`; 
        this._bind();
        this._setEventListeners();
    }
    
    private async _bind() {
        this._titleElement.textContent = this.metric ? "Edit Metric": "Create Metric";

        if (this.metric) {                
            this._nameInputElement.value = this.metric.name;  
        } else {
            this._deleteButtonElement.style.display = "none";
        }     
    }

    private _setEventListeners() {
        this._saveButtonElement.addEventListener("click", this.onSave);
        this._deleteButtonElement.addEventListener("click", this.onDelete);
    }

    private disconnectedCallback() {
        this._saveButtonElement.removeEventListener("click", this.onSave);
        this._deleteButtonElement.removeEventListener("click", this.onDelete);
    }

    public onSave() {
        const metric = {
            id: this.metric != null ? this.metric.id : null,
            name: this._nameInputElement.value
        } as Metric;
        
        this.dispatchEvent(new MetricAdd(metric));            
    }

    public onDelete() {        
        const metric = {
            id: this.metric != null ? this.metric.id : null,
            name: this._nameInputElement.value
        } as Metric;

        this.dispatchEvent(new MetricDelete(metric));         
    }

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "metric-id":
                this.metricId = newValue;
                break;
            case "metric":
                this.metric = JSON.parse(newValue);
                if (this.parentNode) {
                    this.metricId = this.metric.id;
                    this._nameInputElement.value = this.metric.name != undefined ? this.metric.name : "";
                    this._titleElement.textContent = this.metricId ? "Edit Metric" : "Create Metric";
                }
                break;
        }           
    }

    public metricId: any;
    public metric: Metric;
    
    private get _titleElement(): HTMLElement { return this.querySelector("h2") as HTMLElement; }
    private get _saveButtonElement(): HTMLElement { return this.querySelector(".save-button") as HTMLElement };
    private get _deleteButtonElement(): HTMLElement { return this.querySelector(".delete-button") as HTMLElement };
    private get _nameInputElement(): HTMLInputElement { return this.querySelector(".metric-name") as HTMLInputElement;}
}

customElements.define(`ce-metric-edit-embed`,MetricEditEmbedComponent);
