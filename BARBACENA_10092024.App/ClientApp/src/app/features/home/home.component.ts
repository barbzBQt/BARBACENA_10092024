import { Component, OnInit } from '@angular/core';
import { Video } from 'src/app/interfaces/video.model';
import { VideoService } from 'src/app/services/video.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  videos: Video[] = [];
  serverUrl = 'http://127.0.0.1:8080/';
  videoFilePath = '';

  constructor(private videoService: VideoService) {}

  ngOnInit(): void {
    this.videoService.getAllVideos().subscribe((data) => {
      this.videos = data;
    });
  }
}
