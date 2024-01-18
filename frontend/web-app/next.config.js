/** @type {import('next').NextConfig} */
const nextConfig = {
    images: {
        domains: [
            'cdn.pixabay.com'
        ]
    },
    logging: {
        fetches: {
            fetchUrl: true,
        },
    }

}

module.exports = nextConfig
