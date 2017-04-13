import { Metric } from "./metric.model";

export const metricActions = {
    ADD: "[Metric] Add",
    EDIT: "[Metric] Edit",
    DELETE: "[Metric] Delete",
    METRICS_CHANGED: "[Metric] Metrics Changed"
};

export class MetricEvent extends CustomEvent {
    constructor(eventName:string, metric: Metric) {
        super(eventName, {
            bubbles: true,
            cancelable: true,
            detail: { metric }
        });
    }
}

export class MetricAdd extends MetricEvent {
    constructor(metric: Metric) {
        super(metricActions.ADD, metric);        
    }
}

export class MetricEdit extends MetricEvent {
    constructor(metric: Metric) {
        super(metricActions.EDIT, metric);
    }
}

export class MetricDelete extends MetricEvent {
    constructor(metric: Metric) {
        super(metricActions.DELETE, metric);
    }
}

export class MetricsChanged extends CustomEvent {
    constructor(metrics: Array<Metric>) {
        super(metricActions.METRICS_CHANGED, {
            bubbles: true,
            cancelable: true,
            detail: { metrics }
        });
    }
}
