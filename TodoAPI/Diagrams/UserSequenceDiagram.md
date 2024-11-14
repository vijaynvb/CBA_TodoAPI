//create sequence diagram for the flow of crud operations on todos and users model by verifying the #file:'TodosController.cs'and #file:'UsersController.cs'
```mermaid
Client -> UsersController: POST /api/Users
UsersController -> TodoDBContext: Add User
TodoDBContext -> Database: Save Changes
UsersController -> Client: Return Created User

Client -> UsersController: GET /api/Users/{id}
UsersController -> TodoDBContext: Get User by ID
TodoDBContext -> Database: Retrieve User
UsersController -> Client: Return User

Client -> UsersController: PUT /api/Users/{id}
UsersController -> TodoDBContext: Update User
TodoDBContext -> Database: Save Changes
UsersController -> Client: Return NoContent

Client -> UsersController: DELETE /api/Users/{id}
UsersController -> TodoDBContext: Get User by ID
TodoDBContext -> Database: Retrieve User
UsersController -> TodoDBContext: Remove User
TodoDBContext -> Database: Save Changes
UsersController -> Client: Return NoContent

Client -> TodosController: POST /api/Todos
TodosController -> TodoDBContext: Add Todo
TodoDBContext -> Database: Save Changes
TodosController -> Client: Return Created Todo

Client -> TodosController: GET /api/Todos/{id}
TodosController -> TodoDBContext: Get Todo by ID
TodoDBContext -> Database: Retrieve Todo
TodosController -> Client: Return Todo

Client -> TodosController: PUT /api/Todos/{id}
TodosController -> TodoDBContext: Update Todo
TodoDBContext -> Database: Save Changes
TodosController -> Client: Return NoContent

Client -> TodosController: DELETE /api/Todos/{id}
TodosController -> TodoDBContext: Get Todo by ID
TodoDBContext -> Database: Retrieve Todo
TodosController -> TodoDBContext: Remove Todo
TodoDBContext -> Database: Save Changes
TodosController -> Client: Return NoContent
```