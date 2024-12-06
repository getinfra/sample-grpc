# Sample GRPC application

Welcome to **getinfra.samples.grpc**, a .NET-based API application that demonstrates handling gRPC requests and displaying information such as request headers and client IP addresses. This project is built with ASP.NET Core for simplicity and performance.

---

## Features

- **Greeter/SayHello**: Prints the hello and request headers and the client's IP address.
- Lightweight and designed for quick demonstration.
- Easily extendable for more complex scenarios.

---

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
3. [Endpoint Details](#endpoint-details)
4. [Examples](#examples)
5. [License](#license)

---

## Installation

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

### Steps

1. Clone this repository:

   ```bash
   git clone https://github.com/getinfra/sample-grpc.git
   cd sample-api
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

---

## Usage

1. Run the application:

   ```bash
   dotnet run
   ```

2. The server will start on `http://localhost:5085`.

---

## Proto Details

Proto file can by found in `Protos` folder

#### Sample Response

```json
{
    "headers": [
        {
            "key": "user-agent",
            "value": "grpc-node-js/1.11.0-postman.1"
        }
    ],
    "message": "Hello your name"
}
```

---

## Examples

### grpcurl

```bash
 grpcurl -d '{"name": "Your name"}' localhost:7023 Greeter/SayHello
```


---

## License

This project is licensed under the [MIT License](LICENSE).

---


Feel free to modify the code for your specific use case!
