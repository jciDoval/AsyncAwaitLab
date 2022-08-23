import http from 'k6/http';
import { check } from 'k6';

export const options = {
    vus: 200,
    duration: '30s',
    thresholds:{
        'http_req_duration': ['p(95)<200']
    }
};

export default() => {
    
    const res = http.get('https://localhost:7067/Weather/AsyncWeather');

    check(res, {
        'is status 200': (r) => r.status ===200,
    });
};
