# Moolah To-Do App

> Full-stack sample: .NET 9 API + Vue 3 front-end  
> A simple To-Do list with two storage providers (SQLite DB & in-memory) and a factory toggle in the UI.

---

## 🛠️ Prerequisites

- **.NET 9 SDK**  
- **Node.js** (v18+) and **npm**  
- (Optional) Git

---

## 🚀 Getting Started

Clone & cd into the project:

```bash
git clone https://github.com/RutwikW/moolah-todo.git
cd moolah-todo
```

### 1. Backend API

```bash
cd server        # go into the server folder
dotnet restore   # install NuGet packages
dotnet build     # compile
dotnet run       # starts on http://localhost:5078
```

- **Swagger UI:** http://localhost:5078/swagger/index.html  
- **API endpoint:** `GET http://localhost:5078/api/ToDos`

### 2. Front-end Client

_Open a new terminal:_

```bash
cd client       # go into the client folder
npm install     # install npm dependencies
npm run serve   # starts on http://localhost:8080
```

- `npm run serve` — hot-reload dev server  
- `npm run build` — production bundle in `/dist`  
- `npm run lint`  — runs ESLint auto-fix  

---

## 📂 Folder Structure

```
moolah-todo/
├── server/             # .NET Web API
│   ├── Controllers/    # API controllers
│   ├── Models/         # EF Core entities
│   ├── Providers/      # Db vs in-memory implementations
│   └── Program.cs      # minimal hosting setup
└── client/             # Vue 3 SPA
    ├── src/
    │   ├── components/ # ToDoList, ProviderSelector, etc.
    │   └── main.js     # entry point
    └── vue.config.js   # Vue CLI tweaks
```

---

## ⚙️ Configuration

No extra env variables are needed right now—everything runs on the defaults:

- SQLite DB file: `server/todo.db`  
- API port: `5078`  
- Vue dev port: `8080`

---

## 🤝 Contributing

1. Fork the repo  
2. Create a feature branch (`git checkout -b feature/foo-bar`)  
3. Commit your changes (`git commit -am 'Add foo'`)  
4. Push to the branch (`git push origin feature/foo-bar`)  
5. Open a Pull Request  

---

## 📄 License

MIT © Rutwik Wagh
