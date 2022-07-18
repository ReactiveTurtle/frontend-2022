import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { TodoListPageComponent } from "./todo-list-page/todo-list-page.component";

const routes: Routes = [
    {
        path: 'todo-list',
        component: TodoListPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class TodoListRoutingModule { }
