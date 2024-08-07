"use client";

import React, { useState } from 'react';
import axios from 'axios';
import { useRouter } from 'next/navigation';
import Cookie from 'js-cookie';

const Page = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState<string | null>(null);
    const router = useRouter();

    const handleSubmit = async (event: React.FormEvent) => {
        event.preventDefault();
        try {
            const response = await axios.post('http://localhost:5006/User/login', {
                email,
                password
            });
            // handle successful login, e.g., storing token, redirecting, etc.
            console.log(response.data);
            const { token } = response.data;

            Cookie.set('token', token, { expires: 1 });
            router.push('/home');
        } catch (err: any) {
            setError(err.response?.data?.message || 'An error occurred');
        }
    };

    return (
        <div className="flex items-center justify-center h-screen bg-gray-100">
            <div
                className="flex w-full h-full"
                style={{
                    backgroundImage: 'url("/background.png")',
                    backgroundSize: 'cover',
                    backgroundPosition: 'center'
                }}
            >
                <div className="flex flex-1">
                    {/* Left section */}
                    <div className='flex-1'></div>

                    {/* Right section */}
                    <div className=' flex flex-1 items-center justify-center'>
                        <div className="bg-white bg-opacity-90 p-8 rounded-lg shadow-md w-full max-w-xl mx-auto ">
                            <div className='w-full'>
                                <h2 className="text-4xl font-bold  text-center">Chào mừng bạn đến với</h2>
                                <h2 className="text-4xl font-bold mb-6 text-center">HIS MEETING</h2>
                                <form onSubmit={handleSubmit}>
                                    <div className="mb-4">
                                        <label className="block text-gray-700">Email</label>
                                        <input
                                            type="email"
                                            value={email}
                                            onChange={(e) => setEmail(e.target.value)}
                                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring focus:border-blue-300"
                                            required
                                        />
                                    </div>
                                    <div className="mb-6">
                                        <label className="block text-gray-700">Password</label>
                                        <input
                                            type="password"
                                            value={password}
                                            onChange={(e) => setPassword(e.target.value)}
                                            className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring focus:border-blue-300"
                                            required
                                        />
                                    </div>
                                    {error && <p className="text-red-500 text-sm mb-4">{error}</p>}
                                    <div className='flex justify-center items-center gap-4'>
                                        <button
                                            type="submit"
                                            className="w-24 bg-blue-500 text-white py-2 px-4 rounded-lg hover:bg-blue-600 transition-colors"
                                        >
                                            Login
                                        </button>
                                        {/* forgot password */}
                                        <button className='flex text-center mt-2'>Quên mật khẩu?</button>
                                    </div>

                                </form>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    );
};

export default Page;
