import { Component, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';
 
@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  constructor() { }
  connection: signalR.HubConnection;
 
  ngOnInit(): void {
    this.connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:50414/chat").build();
  
  this.connection.start().then(e=>console.log("connected")).catch(function (e) {
    console.log(e);
  });
  this.connection.on("receivemessage", data => {
    console.log(data);
  });

    //this.startlisten().subscribe(e => console.log(e));
  }

  invodeOurMethod() {
    this.connection.invoke(`sendmessage`, `Mohamed Data.`)
      .then();
  }
}
