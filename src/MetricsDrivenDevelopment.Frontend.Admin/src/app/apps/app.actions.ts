import { App } from "./app.model";

export const appActions = {
    ADD: "[App] Add",
    EDIT: "[App] Edit",
    DELETE: "[App] Delete",
    APPS_CHANGED: "[App] Apps Changed"
};

export class AppEvent extends CustomEvent {
    constructor(eventName:string, app: App) {
        super(eventName, {
            bubbles: true,
            cancelable: true,
            detail: { app }
        });
    }
}

export class AppAdd extends AppEvent {
    constructor(app: App) {
        super(appActions.ADD, app);        
    }
}

export class AppEdit extends AppEvent {
    constructor(app: App) {
        super(appActions.EDIT, app);
    }
}

export class AppDelete extends AppEvent {
    constructor(app: App) {
        super(appActions.DELETE, app);
    }
}

export class AppsChanged extends CustomEvent {
    constructor(apps: Array<App>) {
        super(appActions.APPS_CHANGED, {
            bubbles: true,
            cancelable: true,
            detail: { apps }
        });
    }
}
