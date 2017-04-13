import { MetricAdd, MetricDelete, MetricEdit, metricActions } from "./metric.actions";
import { Metric } from "./metric.model";
import { MetricService } from "./metric.service";

const template = require("./metric-master-detail.component.html");
const styles = require("./metric-master-detail.component.scss");

export class MetricMasterDetailComponent extends HTMLElement {
    constructor(
        private _metricService: MetricService = MetricService.Instance	
	) {
        super();
        this.onMetricAdd = this.onMetricAdd.bind(this);
        this.onMetricEdit = this.onMetricEdit.bind(this);
        this.onMetricDelete = this.onMetricDelete.bind(this);
    }

    static get observedAttributes () {
        return [
            "metrics"
        ];
    }

    connectedCallback() {
        this.innerHTML = `<style>${styles}</style> ${template}`;
        this._bind();
        this._setEventListeners();
    }

    private async _bind() {
        this.metrics = await this._metricService.get();
        this.metricListElement.setAttribute("metrics", JSON.stringify(this.metrics));
    }

    private _setEventListeners() {
        this.addEventListener(metricActions.ADD, this.onMetricAdd);
        this.addEventListener(metricActions.EDIT, this.onMetricEdit);
        this.addEventListener(metricActions.DELETE, this.onMetricDelete);
    }

    disconnectedCallback() {
        this.removeEventListener(metricActions.ADD, this.onMetricAdd);
        this.removeEventListener(metricActions.EDIT, this.onMetricEdit);
        this.removeEventListener(metricActions.DELETE, this.onMetricDelete);
    }

    public async onMetricAdd(e) {

        await this._metricService.add(e.detail.metric);
        this.metrics = await this._metricService.get();
        
        this.metricListElement.setAttribute("metrics", JSON.stringify(this.metrics));
        this.metricEditElement.setAttribute("metric", JSON.stringify(new Metric()));
    }

    public onMetricEdit(e) {
        this.metricEditElement.setAttribute("metric", JSON.stringify(e.detail.metric));
    }

    public async onMetricDelete(e) {

        await this._metricService.remove(e.detail.metric.id);
        this.metrics = await this._metricService.get();
        
        this.metricListElement.setAttribute("metrics", JSON.stringify(this.metrics));
        this.metricEditElement.setAttribute("metric", JSON.stringify(new Metric()));
    }

    attributeChangedCallback (name, oldValue, newValue) {
        switch (name) {
            case "metrics":
                this.metrics = JSON.parse(newValue);

                if (this.parentNode)
                    this.connectedCallback();

                break;
        }
    }

    public get value(): Array<Metric> { return this.metrics; }

    private metrics: Array<Metric> = [];
    public metric: Metric = <Metric>{};
    public get metricEditElement(): HTMLElement { return this.querySelector("ce-metric-edit-embed") as HTMLElement; }
    public get metricListElement(): HTMLElement { return this.querySelector("ce-metric-list-embed") as HTMLElement; }
}

customElements.define(`ce-metric-master-detail`,MetricMasterDetailComponent);
