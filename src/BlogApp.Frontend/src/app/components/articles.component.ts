import { Article } from "../models";
import { toPageListFromInMemory, PaginatedComponent } from "../pagination";

const template = require("./articles.component.html");
const styles = require("./articles.component.scss");

export class ArticlesComponent extends PaginatedComponent<Article> {
    constructor() {
        super(5, 1, ".next", ".previous");
    }
    
    connectedCallback() {
        super.connectedCallback({ template, styles });
        this.setEventListeners();
    }

    public bind() {
        
    }

    public render() {        
        this.pagedList = toPageListFromInMemory(this.entities, this.pageNumber, this.pageSize);
        this._totalPagesElement.textContent = JSON.stringify(this.pagedList.totalPages);
        this._currentPageElement.textContent = JSON.stringify(this.pageNumber);

        this._containerElement.innerHTML = "";
        for (let i = 0; i < this.pagedList.data.length; i++) {
            const el = document.createElement(`ce-article`) as any;
            el.article = this.pagedList.data[i];
            this._containerElement.appendChild(el);
        }
    }

    private get _currentPageElement(): HTMLElement { return this.querySelector(".current-page") as HTMLElement; }

    private get _totalPagesElement(): HTMLElement { return this.querySelector(".total-pages") as HTMLElement; }

    private get _containerElement(): HTMLElement { return this.querySelector(".container") as HTMLElement; }

    private _articles: Array<Article> = [];

    public get articles(): Array<Article> {
        return this._articles;
    }

    public set articles(value: Array<Article>) {        
        this._articles = value;
        this.entities = value;
        this.render();
    }
}

customElements.define(`ce-articles`,ArticlesComponent);
