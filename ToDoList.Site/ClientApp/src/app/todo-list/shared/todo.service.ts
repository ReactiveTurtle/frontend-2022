import { Injectable } from "@angular/core";
import { ITodo } from './todo.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class TodoService {
    private readonly apiUrl: string = 'http://localhost:4200/rest/Todo';

    constructor(private httpClient: HttpClient) {
    }

    public addTodo(todo: ITodo): Observable<null> {
        return this.httpClient.post<null>(`${this.apiUrl}/create`, todo);
    }

    public completeTodo(id: number): Observable<null> {
        return this.httpClient.put<null>(`${this.apiUrl}/${id}/complete`, null);
    }

    public deleteTodo(id: number): Observable<object> {
        return this.httpClient.delete(`${this.apiUrl}/${id}/delete`);
    }

    public getTodos(): Observable<ITodo[]> {
        return this.httpClient.get<ITodo[]>(this.apiUrl);
    }
}
