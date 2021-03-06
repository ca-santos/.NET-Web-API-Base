gcloud builds submit --tag gcr.io/locadora-moviemaker/locadora-moviemaker

gcloud run deploy --image gcr.io/locadora-moviemaker/locadora-moviemaker