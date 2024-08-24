export default function serializeResponseError(err) {
    err = err.response.data.output
    return {
        statusCode: err.statusCode,
        devMessage: err.payload.error,
        message: err.payload.message
    }
}