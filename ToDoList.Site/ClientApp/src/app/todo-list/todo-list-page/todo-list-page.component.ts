import { Component, OnInit } from '@angular/core';
import { ITodo } from "../shared/todo.interface";
import { TodoService } from "../shared/todo.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
    templateUrl: './todo-list-page.component.html',
    styleUrls: ['./todo-list-page.component.scss'],
    providers: [TodoService]
})
export class TodoListPageComponent implements OnInit {
    public inProgressItems: ITodo[];
    public doneItems: ITodo[];

    public form: FormGroup;

    constructor(private todoService: TodoService) {
        this.reloadTodos();
    }

    private reloadTodos(): void {
        this.todoService.getTodos().subscribe(todos => {
            this.inProgressItems = todos.filter(todo => !todo.isDone);
            this.doneItems = todos.filter(todo => todo.isDone);
        })
    }

    public ngOnInit(): void {
        this.form = new FormGroup({
            title: new FormControl(null, [Validators.required])
        });
    }

    public addItem(): void {
        if (this.form.invalid) {
            return;
        }
        this.todoService.addTodo({
            title: this.titleControl.value,
            isDone: false
        }).subscribe(() => {
            this.reloadTodos();
            this.titleControl.setValue(null);
            this.form.markAsUntouched();
        });
    }

    public completeTodo(todo: ITodo): void {
        this.todoService.completeTodo(todo.id).subscribe(() => {
            this.reloadTodos();
        });
    }

    public deleteTodo(todo: ITodo): void {
        this.todoService.deleteTodo(todo.id).subscribe(() => {
            this.reloadTodos();
        });
    }

    get titleControl(): AbstractControl {
        return this.form.get('title');
    }
}
