import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-stream',
  templateUrl: './stream.component.html',
  styleUrls: ['./stream.component.css']
})
export class StreamComponent implements OnInit{
  videoPath: string = '';
  serverUrl = 'http://127.0.0.1:8080/';

  constructor(private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log(params)
      this.videoPath = this.serverUrl + 'Videos/' + params['filename'];
    });
  }
}
