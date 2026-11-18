from fastapi import FastAPI

app = FastAPI(
    title="Academic Risk ML Service",
    version="0.1.0"
)

@app.get("/health")
def health_check():
    return {
        "status": "healthy",
        "service": "Academic Risk ML Service",
        "model_loaded": False
    }