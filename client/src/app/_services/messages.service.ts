import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { getPaginationHeaders, getPaginationResult } from './paginationHelper';
import { Message } from '../_models/message';

@Injectable({
  providedIn: 'root',
})
export class MessagesService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getMessage(pagenumber: number, pageSize: number, container: string) {
    let params = getPaginationHeaders(pagenumber, pageSize);
    params = params.append('Container', container);
    return getPaginationResult<Message[]>(
      this.baseUrl + 'messages',
      params,
      this.http
    );
  }

  getMessageThread(username: string) {
    return this.http.get<Message[]>(
      this.baseUrl + 'messages/thread/' + username
    );
  }
  sendMessage(username: string, content: string) {
    return this.http.post<Message>(this.baseUrl + 'messages', {
      recipientUsername: username,
      content,
    });
  }
}
