# Podstawy Teleinformatyki - Projekt

## Installation
### Serwer
After cloning repository go to `Server` directory and install requirements. You can do this by running `pip install -r requirements.txt`. It is adviced to use virtual environment to do so. 
## Usage
### Server
After installing requirements, from `Server` directory run command `python src/api/api.py`. API should be available on `localhost` on port `29345`.  
Server also provides hosted Swagger documentation. The swagger yaml file content is available at `/doc/swagger/` endpoint, while Swagger UI documentation is available at `/doc/swagger/ui/` endpoint. Swagger UI is allowing you to also test all the endpoints from this documentation.