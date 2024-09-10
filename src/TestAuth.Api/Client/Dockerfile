FROM node:lts-alpine AS builder
LABEL webAplication=builder

WORKDIR /usr/src/app
COPY . .

ARG BASE_URL
ENV VITE_BASE_URL=${BASE_URL}

RUN npm install && npm run build

FROM nginx:alpine
LABEL version="1.0"

COPY ./nginx.conf /etc/nginx/nginx.conf

WORKDIR /usr/share/nginx/html
COPY --from=builder  /usr/src/app/dist .
CMD ["nginx", "-g", "daemon off;"]
