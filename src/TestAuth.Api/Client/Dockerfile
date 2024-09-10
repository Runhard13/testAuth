FROM node:lts-alpine AS builder
LABEL webAplication=builder

WORKDIR /src/TestAuth.Api/Client
COPY . .

ARG BASE_URL
ENV VITE_BASE_URL=${BASE_URL}

RUN cd src/TestAuth.Api/Client && ls &&  npm install && npm run build

FROM nginx:alpine
LABEL version="1.0"

COPY /src/TestAuth.Api/Client/nginx.conf /etc/nginx/nginx.conf

WORKDIR /usr/share/nginx/html
COPY --from=builder /src/TestAuth.Api/Client/dist .
CMD ["nginx", "-g", "daemon off;"]
