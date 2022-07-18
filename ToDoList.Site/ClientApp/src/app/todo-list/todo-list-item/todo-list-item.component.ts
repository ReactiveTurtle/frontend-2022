import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ITodo } from "../shared/todo.interface";

@Component({
    selector: 'tl-todo-list-item',
    templateUrl:'./todo-list-item.component.html'
})

export class TodoListItemComponent {
    @Input() public item: ITodo;
    @Output() public done: EventEmitter<ITodo> = new EventEmitter<ITodo>();
    @Output() public delete: EventEmitter<ITodo> = new EventEmitter<ITodo>();

    public deleteClicked(): void {
        this.delete.emit(this.item);
    }

    public doneClicked(): void {
        this.done.emit(this.item);
    }
}
