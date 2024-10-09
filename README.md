# BARBACENA_10092024
This project is a simple web application that allows users to upload videos and watch them. The application is built using **Angular** for the frontend and **ASP.NET Core** for the backend. It features video uploads, and a streaming page.

## Features

- **Home Page**: Displays a list of uploaded videos, including their thumbnails, titles, descriptions, and categories.
- **Upload Page**: A form that allows users to upload a video file along with its title, description, and categories.
- **Streaming Page**: Streams the selected video from the home page.
## Technologies Used

- **Frontend**: 
  - Angular
  - Bootstrap for styling

- **Backend**: 
  - ASP.NET Core
  - FFmpeg for thumbnail generation

## Prerequisites

Before running the application, ensure you have the following installed:

- .NET Core SDK
- Node.js and npm
- FFmpeg (added to system PATH)
- Entity Framework Core (Code-first migration)
- A database (e.g., SQL Server, SQLite) for storing video metadata (if applicable)

## Installation

### Backend Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/barbzBQt/BARBACENA_10092024.git
2. Run the scripts fron BARBACENA_10092024\BARBACENA_10092024.Data\Scripts OR Run Migration:
   ```bash
   update-database
3. Build Solution
4. Run BARBACENA_10092024.App
5. Download and copy to C:\BARBACENA_10092024\FFMPEG the ffmpeg.exe from https://ffmpeg.org/download.html#build-windows
6. Install http-server
   ```bash
   npm install -g http-server
7. Run the local server for accessing and the files
   ```bash
   cd C:\BARBACENA_10092024
   http-server
