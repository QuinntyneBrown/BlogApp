import { Metric } from "./metric.model";

const template = require("./metric-list-embed.component.html");
const styles = require("./metric-list-embed.component.scss");

export class MetricListEmbedComponent extends HTMLElement {
    constructor(
        private _document: Document = document
    ) {
        super();
    }


    static get observedAttributes() {
        return [
            "metrics"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
    }

    private async _bind() {        
        for (let i = 0; i < this.metrics.length; i++) {
            let el = this._document.createElement(`ce-metric-item-embed`);
            el.setAttribute("entity", JSON.stringify(this.metrics[i]));
            this.appendChild(el);
        }    
    }

    metrics:Array<Metric> = [];

    attributeChangedCallback(name, oldValue, newValue) {
        switch (name) {
            case "metrics":
                this.metrics = JSON.parse(newValue);
                if (this.parentElement)
                    this.connectedCallback();
                break;
        }
    }
}

customElements.define("ce-metric-list-embed", MetricListEmbedComponent);
