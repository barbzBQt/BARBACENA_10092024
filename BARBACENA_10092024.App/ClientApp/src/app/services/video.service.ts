import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Video } from '../interfaces/video.model';

@Injectable({
  providedIn: 'root'
})
export class VideoService {
  private apiUrl = 'http://localhost:7193/api/videos';

  constructor(private http: HttpClient) {}

  getAllVideos(): Observable<Video[]> {
    return this.http.get<Video[]>(`${this.apiUrl}/all`);
  }
}
