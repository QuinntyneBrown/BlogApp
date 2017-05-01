import { RouterOutlet } from "./router";

export class AppRouterOutletComponent extends RouterOutlet {
    constructor(el: any) {
        super(el);
    }

    connectedCallback() {
        this.setRoutes([
            { path: "/", name: "splash" },
            { path: "/articles", name: "splash" },
            { path: "/articles/:slug", name: "article-page" },
            { path: "/preview/:slug", name: "article-page" },
            { path: "/error", name: "error" }            
        ] as any);
        
        super.connectedCallback();
    }

}

customElements.define(`ce-app-router-oulet`, AppRouterOutletComponent);