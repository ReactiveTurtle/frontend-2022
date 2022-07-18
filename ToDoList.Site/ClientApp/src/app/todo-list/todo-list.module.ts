import { NgModule } from "@angular/core";
import { TodoListPageComponent } from "./todo-list-page/todo-list-page.component";
import { TodoListRoutingModule } from "./todo-list-routing.module";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { TodoListItemComponent } from "./todo-list-item/todo-list-item.component";
import { MatIconModule } from "@angular/material/icon";
import { TodoService } from "./shared/todo.service";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";

@NgModule({
    declarations: [
        TodoListPageComponent,
        TodoListItemComponent
    ],
    imports: [
        HttpClientModule,
        MatButtonModule,
        MatCardModule,
        MatListModule,
        TodoListRoutingModule,
        CommonModule,
        MatIconModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule
    ],
    providers: [
        TodoService
    ]
})
export class TodoListModule {
}
