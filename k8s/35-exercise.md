## Stworzyc wdrozenie redis wraz z wewentrznym serwisem o nazwie redis (slucha na porcie 6379)

```
apiVersion: apps/v1
kind: Deployment
metadata:
  name: azure-vote-back
spec:
  replicas: 1
  selector:
    matchLabels:
      app: azure-vote-back
  template:
    metadata:
      labels:
        app: azure-vote-back
    spec:
      nodeSelector:
        "beta.kubernetes.io/os": linux
      containers:
      - name: azure-vote-back
        image: mcr.microsoft.com/oss/bitnami/redis:6.0.8
        env:
        - name: ALLOW_EMPTY_PASSWORD
          value: "yes"
        ports:
        - containerPort: 6379
          name: redis
```

## Stworzenie deployemtu dla apliakcji

- obraz to mcr.microsoft.com/azuredocs/azure-vote-front:v1
- slucha ona na porcie 80
- zmienej srodowiskowej o nazwie REDIS w ktorej jest nazwa serwisu z redisem

## Wsyatwic za pomoca ingress do swiata na domenie vote-<nazwisko>.gp.kaluzny.io